var OpenWeatherAppKey = "2c24436d9d9a44bc6d9eae99d7835bb9"; //5bb30b963a0d79993
b96acd6ce552b0c
function getWeatherWithCityName() {
    var cityName = $('#city-name-input').val();
    var queryString =
        'http://api.openweathermap.org/data/2.5/weather?q='
        + cityName + '&appid=' + OpenWeatherAppKey;
    $.getJSON(queryString, function (results) {
        showWeatherData(results);
    }).fail(function (jqXHR) {
        $('#error-msg').show();
        $('#error-msg').text("Error retrieving data. " + jqXHR.statusText);
    });
    return false;
}
function showWeatherData(results) {
    if (results.weather.length) {
        $('#error-msg').hide();
        $('#weather-data').show();
        $('#title').text(results.name);
        $('#temperature').text(results.main.temp);
        $('#wind').text(results.wind.speed);
        $('#humidity').text(results.main.humidity);
        $('#visibility').text(results.weather[0].main);
       
        var sunriseDate = new Date(results.sys.sunrise * 1000);
        $('#sunrise').text(sunriseDate.toLocaleTimeString());
        var sunsetDate = new Date(results.sys.sunset * 1000);
        $('#sunset').text(sunsetDate.toLocaleTimeString());
        $('#temp_min').text(Math.round(results.main.temp_min - 272.15));
        $('#temp_max').text(Math.round(results.main.temp_max - 272.15));

        

    } else {
        $('#weather-data').hide();
        $('#error-msg').show();
        $('#error-msg').text("Error retrieving data. ");
    }
}