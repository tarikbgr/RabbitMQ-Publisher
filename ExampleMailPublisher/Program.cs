using Inbx;
using MassTransit;

var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(
        "localhost",
        5672,
        "/",
        "ExampleMailPublisher",
        h =>
        {
            h.Username("admin");
            h.Password("123456");
        }
    );
});

for (int i = 0; i < 1000; i++)
{
    await bus.Publish<IMessageMail>(new
    {
        Id = i,
        Email = "tarik@useinbox.com",
        Host = "123.123.12.23",
        Port = 3253
    });
}

