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
    return tokenStr + 'BQBVbyDV1MDddDKVJH9D_vgYoqVlJCYbIYxoFolIMxFJmtdcKW5jLkoTq61hIR_ZBZQi_QkMnIgnHvS8m1X8YnDTnkODn9aoZlTf_JdWmNqdWylhjvLhz_rEdEVUZBxsai1D_pAFsS9GVaMT2JEVqvmmsgQy9mm6gZmHjd_NXvh53Sh-GtJFZgfRlDPrFkAwqyd9cDEStCcNiOfweeQSilWZXVh3JBfD1kJiGHTtBwJoL6DfkVa2JGrygYY1HY0_wuPzpkgtKxkW5k9z-u8e-W0fJmEV';
}

export function setCookie(token) {
    let tokenStr = 'token=';
    document.cookie = tokenStr + token;
}