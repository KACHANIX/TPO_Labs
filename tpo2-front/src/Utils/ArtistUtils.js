import api from "../GetToken";
import {msToHMS} from "./TimeConverter";

let Api = api();

export async function getSavedArtists() {
    let array = [];
    await Api.getFollowedArtists().then(function (data) {
        data.artists.items.map(artist => {
            // el.track.duration = msToHMS(el.track.duration_ms);
            array.push(artist);
        });
    });
    return array;
}

export async function getMostArtists() {
    let array = [];
    await Api.getMyTopArtists().then(function (data) {
        data.items.map(artist => {
            array.push(artist);
        })
    });
    return array;
}

export async function getArtist(artistId) {
    let artist = null;
    await Api.getArtist(artistId).then(function (data) {
        artist = data;
    });
    return artist;
}

export async function getArtistsAlike(artistId) {
    let array = [];
    await Api.getArtistRelatedArtists(artistId).then(function (data) {
        console.log(data);
        array = data.artists;
    });
    return array;
}

export async function getArtistsAlbums(artistId) {
    let array = [];
    await Api.getArtistAlbums(artistId).then(function (data) {
        array = data.items;
    });
    return array;
}

export async function getArtistsTopTracks(artistId) {
    let array = [];
    await Api.getArtistTopTracks(artistId, 'us').then(function (data) {
        data.tracks.forEach(track => {
            track.duration = msToHMS(track.duration_ms);
            array.push(track);
        });
    });
    return array;
}

export async function followArtist(artistId) {
    await Api.followArtists([artistId])
}

export async function unfollowArtist(artistId) {
    await Api.unfollowArtists([artistId])
}