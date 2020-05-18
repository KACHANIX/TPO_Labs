import api from "../GetToken"

let Api = api();

export async function getSavedTracks() {
    let array = [];
    await Api.getMySavedTracks().then(function (data) {
        data.items.map(el => {
            el.track.duration = msToHMS(el.track.duration_ms);
            array.push(el.track);
        })
    });
    return array;
}

export async function getRecentTracks() {
    let array = [];

    await Api.getMyRecentlyPlayedTracks().then(function (data) {
        data.items.forEach(el => {
            el.track.duration = msToHMS(el.track.duration_ms);
            array.push(el.track);
        })
    });
    return array;
}

export async function getTopTracks() {
    let array = [];
    try {
        await Api.getMyTopTracks().then(function (data) {
            data.items.forEach(el => {
                el.track.duration = msToHMS(el.track.duration_ms);
                array.push(el.track)
            })
        });

    } catch (e) {
        return []
    }
    return array;
}

function msToHMS(ms) {
    var seconds = ms / 1000;
    var pad = function (num, size) {
            return ('000' + num).slice(size * -1);
        },
        time = parseFloat(seconds).toFixed(3),
        hours = Math.floor(time / 60 / 60),
        minutes = Math.floor(time / 60) % 60,
        seconds1 = Math.floor(time - minutes * 60),
        milliseconds = time.slice(-3);

    return pad(minutes, 2) + ':' + pad(seconds1, 2);
}