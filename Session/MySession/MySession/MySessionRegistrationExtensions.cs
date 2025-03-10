namespace MySession.MySession
{
    public static class MySessionRegistrationExtensions
    {
        public static IServiceCollection AddMySession(this IServiceCollection services)
        {
            services.AddSingleton<IMySessionStorageEngine>(services =>
            {
                var path = Path.Combine(services.GetRequiredService<IHostEnvironment>().ContentRootPath, "session");
                Directory.CreateDirectory(path);

                return new FileMySessionStorageEngine(path);
            });

            services.AddScoped<MySessionScopedContainer>();
            services.AddSingleton<IMySessionStorage, MySessionStorage>();

            return services;
        }
    }
}
