using bengogogadget.core.Infrastructure;
using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Commands;
using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Data;
using freedom.exchange.api.Queries;
using freedom.exchange.api.Queries.Interfaces;

namespace freedom.exchange.api.Bootstrap
{
    public static class Dependencies
    {
        public static void Register(IServiceCollection services)
        {
            Infrastructure(services);
            Commands(services);
            Queries(services);
        }

        private static void Infrastructure(IServiceCollection services)
        {
            services.AddSingleton<IUuidGenerator, UuidGenerator>();
            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        }

        private static void Commands(IServiceCollection services)
        {
            services.AddTransient<ICreateUser, CreateUser>();
            services.AddTransient<ICreateMessagingGroup, CreateMessagingGroup>();
            services.AddTransient<ICreateMessage, CreateMessage>();
            services.AddTransient<IUpdateMessage, UpdateMessage>();
            services.AddTransient<IUpdateUserMessage, UpdateUserMessage>();
        }

        private static void Queries(IServiceCollection services)
        {
            services.AddTransient<IGetUserMessagingGroups, GetUserMessageGroups>();
            services.AddTransient<IGetMessagingGroupUsers, GetMessageGroupUsers>();
            services.AddTransient<IGetUserMessages, GetUserMessages>();
        }
    }
}
