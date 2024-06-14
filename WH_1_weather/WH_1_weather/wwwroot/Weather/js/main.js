

import render from "./modules/render.js";
import weatherApi from "./modules/OWAPIRequest.js"
const renderWeather = new render.RenderWheather();
const getWeather = new weatherApi.Weather();
$(document).ready(() => {


    
    
    getWeather.GetCommonWeather($(`#country`).val(), $(`#city`).val(), `ru`).then((data) => {
        renderWeather.RenderComonWeather(data);
    });
    getWeather.GetForeCastWeather($(`#country`).val(), $(`#city`).val(), `ru`).then((data) => {
        renderWeather.RenderForecast(data);
        
    });

    $(`#city`).on(`change`, () => {
       
        getWeather.GetCommonWeather($(`#country`).val(), $(`#city`).val(), $(`#lang`).val()).then((data) => {
            
            if (getWeather.GetStatus() === 200) {
                $(`#tipTool`).css(`opacity`, `0`);
                renderWeather.RenderComonWeather(data);
            } else {
                $(`#tipTool`).css(`opacity`, `1`);
            }
         
            
        });
        getWeather.GetForeCastWeather($(`#country`).val(), $(`#city`).val(), $(`#lang`).val()).then((data) => {
            if(getWeather.GetStatus()===200){
                $(`#tipTool`).css(`opacity`, `0`);
                renderWeather.RenderForecast(data);
            } else {
                $(`#tipTool`).css(`opacity`, `1`);
            }
            
        });
    })

    $(`#lang`).on(`change`,()=>{
        getWeather.GetCommonWeather($(`#country`).val(), $(`#city`).val(), $(`#lang`).val()).then((data) => {
            renderWeather.RenderComonWeather(data);
        });
        getWeather.GetForeCastWeather($(`#country`).val(), $(`#city`).val(), $(`#lang`).val()).then((data) => {
            renderWeather.RenderForecast(data);
            
        });
    })
  

   



});





