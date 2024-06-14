class Weather {

    #response;
    #status;
    GetCommonWeather(country, city, lang) {

        return this.#RequestAPI(`https://api.openweathermap.org/data/2.5/weather?q=${city},${country}&lang=${lang}&appid=f65c4cacca05feca0291118ef5a89c3b&units=metric`);

    }
    async  #RequestAPI(URL) {
        this.#response = await fetch(URL)
            .then((response) => {
                this.#status = response.status;
                return response.json();
            });

        return this.#response;
    }

    GetForeCastWeather(country, city, lang) {
        return this.#RequestAPI(`https://api.openweathermap.org/data/2.5/forecast/?q=${city},${country}&lang=${lang}&appid=f65c4cacca05feca0291118ef5a89c3b&units=metric`);

    }





    GetStatus() {

        return this.#status;
    }

}


export default { Weather };