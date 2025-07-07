using Data;

ApplicationConfiguration.Initialize();
Application.Run(new LoginForm());

await ExampleDbContext.Create();