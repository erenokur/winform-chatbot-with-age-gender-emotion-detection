using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace age_gender_detection
{
    public partial class Form1 : Form
    {


        private static readonly CascadeClassifier Classifier = new CascadeClassifier("haarcascade_frontalface_default.xml");



        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

            Load += Form1_Load;
            RobotImageViewer ImageChanger = new RobotImageViewer();
            ImageChanger.Dock = DockStyle.Fill;
            RobotPanel.Controls.Add(ImageChanger);
            DialogBubbles dialogs = new DialogBubbles();
            dialogs.Dock = DockStyle.Fill;
            DialogPanel.Controls.Add(dialogs);
            //RobotPanel.BackColor = Color.Black;
            //VideoPanel.BackColor = Color.Blue;
            LoadCaffeModels();

        }
        bool Started = true;
        private void FiniteStateMachine()
        {
            string TargetGender = null;
            string TargetAge = null;
            // GoogleSpeechRecognition GetUserReponses = new GoogleSpeechRecognition();
            while (Started)
            {
                if (faces != null && faces.Length != 0 && TargetGender == null && TargetAge == null)
                {
                    foreach (var face in faces)
                    {
                        Bitmap target = new Bitmap(face.Width, face.Height);
                        TargetGender = GetGender(target);
                        TargetAge = GetAge(target);
                    }
                }
            }
        }



        #region On Load
        private void Form1_Load(object sender, EventArgs e)
        {
            if (capture == null)
            {
                try
                {
                    capture = new Emgu.CV.VideoCapture(0);
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }

            capture.ImageGrabbed += ProcessFrame;
            _frame = new Mat();
            if (capture != null)
            {
                try
                {
                    capture.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Environment.SetEnvironmentVariable(credential, credential_path);
            //Thread FSM = new Thread(() => FiniteStateMachine());
            //FSM.IsBackground = true;
            //FSM.Start();
        }
        #endregion

        #region Process Picture 
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (capture != null && capture.Ptr != IntPtr.Zero)
            {
                capture.Retrieve(_frame, 0);
                TempImage = _frame.Bitmap;
                AgeImage = new Bitmap(TempImage);
                using (var imageFrame = _frame.Bitmap)
                {
                    if (imageFrame != null)
                    {
                        var grayframe = imageFrame;
                        faces = Classifier.DetectMultiScale(new Emgu.CV.Image<Bgr, Byte>(TempImage), 1.1, 10, Size.Empty); //the actual face detection happens here
                        foreach (var face in faces)
                        {
                            Bitmap target = new Bitmap(face.Width, face.Height);
                            using (Graphics gr = Graphics.FromImage(TempImage))
                            {
                                gr.SmoothingMode = SmoothingMode.AntiAlias;
                                using (Graphics g = Graphics.FromImage(target))
                                {
                                    g.DrawImage(AgeImage, new Rectangle(0, 0, target.Width, target.Height),
                                                     face,
                                                     GraphicsUnit.Pixel);
                                }
                                GetGender(target);
                                GetAge(target);
                                using (Pen thick_pen = new Pen(Color.Blue, 5))
                                {

                                    gr.DrawRectangle(thick_pen, face);
                                    RobotEye.Image = TempImage;
                                }
                            }
                        }
                    }

                }
            }
        }

        #endregion

        #region Get Gender
        private string GetGender(Bitmap Face)
        {
            Mat resim_Mat = new Emgu.CV.Image<Bgr, Byte>(Face).Mat;
            Mat blob = Emgu.CV.Dnn.DnnInvoke.BlobFromImage(resim_Mat, 1, new Size(227, 227), new MCvScalar(78.4263377603, 87.7689143744, 114.895847746), false);
            Gendernet.SetInput(blob, "data");
            var gender_preds = Gendernet.Forward("prob");
            //var gender = gender_list[gender_preds.Step];
            int classId = 0;
            double classProb = 0;
            string Gender = gender_list[getMaxClass(ref gender_preds, ref classId, ref classProb)];
            this.Invoke((MethodInvoker)delegate
            {
                GenderLabel.Text = Gender;
            });
            return Gender;
            //Console.WriteLine(gender_list[getMaxClass(ref gender_preds, ref classId, ref classProb)]);
        }
        #endregion

        #region Get Age
        private string GetAge(Bitmap Face)
        {
            Mat resim_Mat = new Emgu.CV.Image<Bgr, Byte>(Face).Mat;
            Mat blob = Emgu.CV.Dnn.DnnInvoke.BlobFromImage(resim_Mat, 1, new Size(227, 227), new MCvScalar(78.4263377603, 87.7689143744, 114.895847746), false);
            Agenet.SetInput(blob, "data");
            var age_preds = Agenet.Forward("prob");
            //var gender = gender_list[gender_preds.Step];
            int classId = 0;
            double classProb = 0;
            string Age = age_list[getMaxClass(ref age_preds, ref classId, ref classProb)];
            this.Invoke((MethodInvoker)delegate
            {
                AgeLabel.Text = Age;
            });
            return Age;
            //AgeLabel.Text = age_list[getMaxClass(ref age_preds, ref classId, ref classProb)];
            //Console.WriteLine(age_list[getMaxClass(ref age_preds, ref classId, ref classProb)]);
        }
        #endregion

        #region Loading Coffe models
        private void LoadCaffeModels()
        {
            Agenet = new Emgu.CV.Dnn.Net();
            Agenet = Emgu.CV.Dnn.DnnInvoke.ReadNetFromCaffe("deploy_age.prototxt", "age_net.caffemodel");
            Gendernet = new Emgu.CV.Dnn.Net();
            Gendernet = Emgu.CV.Dnn.DnnInvoke.ReadNetFromCaffe("deploy_gender.prototxt", "gender_net.caffemodel");
        }


        int getMaxClass(ref Mat probBlob, ref int classId, ref double classProb)
        {
            Mat probMat = probBlob.Reshape(1, 1); //reshape the blob to 1x1000 matrix
            Point classNumber = new Point();


            var tmp = new Point();
            double tmpdouble = 0;
            CvInvoke.MinMaxLoc(probMat, ref tmpdouble, ref classProb, ref tmp, ref classNumber);

            classId = classNumber.X;
            return classId;
        }
        #endregion

        #region Get Speech Results
        /*public void GetTimedResults(int seconds)
        {
            object dene = StreamingMicRecognizeAsync(seconds);
        }*/

        /*async Task<object> StreamingMicRecognizeAsync(int seconds)
        {
            if (NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                Console.WriteLine("No microphone!");
                return -1;
            }
            var speech = SpeechClient.Create();
            var streamingCall = speech.StreamingRecognize();
            // Write the initial request with the config.
            await streamingCall.WriteAsync(
                new StreamingRecognizeRequest()
                {
                    StreamingConfig = new StreamingRecognitionConfig()
                    {
                        Config = new RecognitionConfig()
                        {
                            Encoding =
                            RecognitionConfig.Types.AudioEncoding.Linear16,
                            SampleRateHertz = 16000,
                            LanguageCode = "tr",
                        },
                        InterimResults = true,
                    }
                });
            // Print responses as they arrive.
            Task printResponses = Task.Run(async () =>
            {
                while (await streamingCall.ResponseStream.MoveNext(
                    default(CancellationToken)))
                {
                    foreach (var result in streamingCall.ResponseStream
                        .Current.Results)
                    {
                        foreach (var alternative in result.Alternatives)
                        {
                            //Console.WriteLine(alternative.Transcript);
                            try
                            {
                                LastSpeechResult = alternative.Transcript;
                                TempSpeechText.Invoke((MethodInvoker)delegate
                                {
                                    TempSpeechText.Text = alternative.Transcript;
                                });

                            }
                            catch
                            {

                            }

                        }
                    }
                }
            });
            // Read from the microphone and stream to API.
            object writeLock = new object();
            bool writeMore = true;
            var waveIn = new NAudio.Wave.WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            waveIn.DataAvailable +=
                (object sender, NAudio.Wave.WaveInEventArgs args) =>
                {
                    lock (writeLock)
                    {
                        if (!writeMore) return;
                        streamingCall.WriteAsync(
                            new StreamingRecognizeRequest()
                            {
                                AudioContent = Google.Protobuf.ByteString
                                    .CopyFrom(args.Buffer, 0, args.BytesRecorded)
                            }).Wait();
                    }
                };
            waveIn.StartRecording();
            Console.WriteLine("Speak now.");
            //DialogBubbles.messageControl1.Add("Sizi dinliyorum", MessageControl.BubblePositionEnum.Right);
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            // Stop recording and shut down.
            waveIn.StopRecording();
            lock (writeLock) writeMore = false;
            await streamingCall.WriteCompleteAsync();
            await printResponses;
            return 0;
        }*/
        #endregion

        #region Variables
        public static string LastSpeechResult = null;
        Rectangle[] faces;
        Emgu.CV.Dnn.Net Agenet;
        Emgu.CV.Dnn.Net Gendernet;
        double[] MODEL_MEAN_VALUES = { 78.4263377603, 87.7689143744, 114.895847746 };
        string[] age_list = { "(0, 2)", "(4, 6)", "(8, 12)", "(15, 20)", "(25, 32)", "(38, 43)", "(48, 53)", "(60, 100)" };
        string[] gender_list = { "Male", "Female" };
        Bitmap AgeImage;
        Bitmap TempImage;
        private VideoCapture capture;
        private Mat _frame;
        #endregion
    }
}
