import SpotifyWebApi from "spotify-web-api-js";

function api(){
    let spotify = new SpotifyWebApi();

    let a = document.cookie;
    // console.log('SUKA');
    // console.log(a.substring(6));
    spotify.setAccessToken(a.substring(6));
    return spotify;
}

export default api;