class RenderWheather {


    RenderComonWeather(data) {
        let span = $(`#commonW`).find(`span`);

        $(span[0]).text(data["name"]);
        $(span[1]).text(`${new Date().toLocaleString(`ua`, { year: "numeric", month: "numeric", day: "numeric" })}`);
        $(span[2]).text(data["weather"]["0"]["description"]);
        $(span[4]).css({ backgroundImage: `url(https://openweathermap.org/img/wn/${data["weather"]["0"]["icon"]}@2x.png)` });
        $(span[3]).text(`Мин. ${data["main"]["temp_min"]}° C`);
        $(span[5]).text(`Макс. ${data["main"]["temp_max"]}° C`);
        $(span[6]).text(`Cейчас. ${data["main"]["temp"]}° C`);
        $(span[7]).text(`${data["wind"]["speed"]} M/C`);

    }

    RenderForecast(data) {

        let forecastCard = $(`.forecastCard`);
        let date = new Date(data["list"][`0`]["dt_txt"].split(' ')[0]).toLocaleString(`ua`, { weekday: "long" });
        $(`#date`).text(date);

        for (let i = 0; i < forecastCard.length; i++) {
            let span = $(forecastCard[i]).find(`span`);
            $(span[0]).text(data["list"][`${i}`]["dt_txt"].split(' ')[1]);
            $(span[1]).css({ backgroundImage: `url(https://openweathermap.org/img/wn/${data["list"][`${i}`]["weather"]["0"]["icon"]}@2x.png)` });
            $(span[2]).text(data["list"][`${i}`]["weather"]["0"]["description"]);
            $(span[3]).text(`${data["list"][`${i}`]["main"]["temp"]}° C`);
            $(span[4]).text(`${data["list"][`${i}`]["wind"]["speed"]} M/C`);

        }
    }

   
};

export default { RenderWheather };

