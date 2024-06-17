namespace HW_2_MiddleWare
{
    public class FromElevenToNineteenMiddleware
    {
        private readonly RequestDelegate _next;

        public FromElevenToNineteenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Query["number"];
            try
            {
               
                int number = Convert.ToInt32(token);
                number = Math.Abs(number);
                string[] Numbers = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

                if(number>10&&number<20) {
                    await context.Response.WriteAsync("Your number is " + Numbers[number % 10 - 1]);
                }else if(number%100>10&& number % 100 < 20) {

                    context.Session.SetString("number", Numbers[number % 10 - 1]);
                }
                else
                {
                    await _next.Invoke(context);

                }

               

            }
            catch (Exception)
            {
                await context.Response.WriteAsync("11-19 Incorrect parameter ");
            }
        }
    }
}
