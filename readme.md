In 2017, a fun project I created using C# win forms and .NET framework 4.7. The project's main goal was to create a simple relationship between a human and a chatbot. The chatbot would analyze the user's age, gender, emotion and respond accordingly. In addition to analyzing the user's age, gender, emotion, the chatbot in this project also needs a camera.

To accomplish this, the project used EmguCV, NAudio, and Google API Speech API. The Google Speech API was used for speech recognition, and the user needs to import their Google credentials and set the environment variable using the following code:

```
Environment.SetEnvironmentVariable(credential, credential_path);

```

The project was generated and tested using Visual Studio 15, and the license is MIT.
