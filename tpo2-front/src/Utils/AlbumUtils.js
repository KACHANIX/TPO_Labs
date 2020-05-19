import api from "../GetToken"
import {async} from "q";
import {msToHMS} from "./TimeConverter";

let Api = api();

export async function getSavedAlbums() {
    let array = [];
    await Api.getMySavedAlbums().then(function (data) {
        data.items.map(el => {
            // el.track.duration = msToHMS(el.track.duration_ms);
            array.push(el.album);
        })
    });
    return array;
}

export async function getNewAlbums() {
    let array = [];
    await Api.getNewReleases().then(function (data) {
        data.albums.items.map(el => {
            array.push(el);
        })
    });
    return array;
}
export async function getAlbum(albumId) {
    let album = null;
    await Api.getAlbum([albumId]).then(function (data) {
        album = data;
        album.tracks.items.forEach(track=>track.duration = msToHMS(track.duration_ms));

    });
    return album;
}