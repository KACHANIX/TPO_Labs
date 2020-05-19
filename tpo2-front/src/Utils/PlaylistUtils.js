import api from "../GetToken";
import {msToHMS} from "./TimeConverter";

let Api = api();
export async function getSavedPlaylists(){
    let currentUser = null;
    await Api.getMe().then(function (data) {
        currentUser = data;
    });
    let array = [];
    await Api.getUserPlaylists(currentUser.id).then(function (data) {
        data.items.forEach((pl)=>{
            if (pl.owner.display_name !=currentUser.display_name)
                array.push(pl)
        });
    })
    return array;
}
export async function getCreatedPlaylists(){
    let currentUser = null;
    await Api.getMe().then(function (data) {
        currentUser = data;
    });
    let array = [];
    await Api.getUserPlaylists(currentUser.id).then(function (data) {
        data.items.forEach((pl)=>{
            if (pl.owner.display_name ==  currentUser.display_name)
                array.push(pl)
        });
        // array = data.items;
    });
    return array;
}
export async function getFeaturedPlaylists(){
    let array = [];
    await Api.getFeaturedPlaylists().then(function (data) {
        console.log(data.playlists.items);
        array = data.playlists.items;
    });
    return array;
}


export async function followPlaylist(id) {
    await Api.followPlaylist(id)
}

export async function unfollowPlaylist(id) {
    await Api.unfollowPlaylist(id)
}

export async function getPlaylist(id){
    let playlist = null;
    let trackList = [];
    await Api.getPlaylist(id).then(function (data) {
        data.tracks.items.forEach(track=>{
            track.track.duration = msToHMS(track.track.duration_ms);
            trackList.push(track.track)
        });
        data.trackList=trackList;
        playlist = data;
    });
    return playlist;
}