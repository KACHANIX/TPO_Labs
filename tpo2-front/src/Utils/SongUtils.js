import api from "../GetToken"
import {msToHMS} from "./TimeConverter";

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

export async function addSongToSaved(songId){
    await Api.addToMySavedTracks([songId]);
}
export async function removeSongFromSaved(songId){
    await Api.removeFromMySavedTracks([songId])
}