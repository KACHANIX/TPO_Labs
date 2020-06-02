import SpotifyWebApi from "spotify-web-api-js";

export function api(){
    let spotify = new SpotifyWebApi();
    let a = getCookie();
    console.log(a);
    spotify.setAccessToken(a.substring(6));
    return spotify;
}

// for correct work
// export function getCookie(){
//     return document.cookie;
// }

// for correct test
export function getCookie(){
    let tokenStr = 'token=';
    return tokenStr + 'BQBhGIZptgV2wwzZCP21rc2dHMc3VwOwfhyM0kbyfPfhXbK3mxUDKQ6SQH3cSOYOU-grUQnrT_DRGXRwTAscxhzWvczN2zhgprkoAdfGHRbMT1E7xt5JfDkPvZkvjuz7p-oZvq2UFF0os_nkG_Zp8e9j4YdueK4Syx_9VnohagXZQSxIYHP7QHKng310aCp-CyWvSaQ8mlVTRNZ06VCLQiNe0PMxJq2MfGq6IBNQPjsfG6CwjVGA6JedVYQW5TaFwZWPhAE5vr9sjV9ohO4EEgoL1LMx';
}

export function setCookie(token) {
    let tokenStr = 'token=';
    document.cookie = tokenStr + token;
}