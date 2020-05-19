import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import {getMostArtists, getSavedArtists} from "../Utils/ArtistUtils";
import * as ReactDOM from "react-dom";
import {getCreatedPlaylists, getFeaturedPlaylists, getSavedPlaylists} from "../Utils/PlaylistUtils";
import PlaylistList from "./PlaylistList";


class Playlists extends Component{

    constructor() {
        super();
        this.savedPlaylists = this.savedPlaylists.bind(this);
        this.createdPlaylists = this.createdPlaylists.bind(this);
        this.featuredPlaylists = this.featuredPlaylists.bind(this);
    }

    async savedPlaylists(){
        let playlists = await getSavedPlaylists();
        console.log(playlists);
        ReactDOM.render(<PlaylistList name='asd' playlists={playlists}/>, document.getElementById('playlists-list'));
        //
        // console.log(artists);
    }
    async createdPlaylists(){
        let playlists = await getCreatedPlaylists();
        console.log(playlists);
        ReactDOM.render(<PlaylistList name='asd' playlists={playlists}/>, document.getElementById('playlists-list'));
        // ReactDOM.render(<ArtistList name='asd' artists={artists}/>, document.getElementById('artists-list'));
        //
        // console.log(artists);
    }
    async featuredPlaylists(){
        let playlists = await getFeaturedPlaylists();
        console.log(playlists);
        ReactDOM.render(<PlaylistList name='asd' playlists={playlists}/>, document.getElementById('playlists-list'));
    }
    render() {
        return(
            <div>
                <div>
                    <b onClick={this.savedPlaylists}>Saved Playlists</b>
                    <b onClick={this.createdPlaylists} style={{marginLeft: 50}}>Created Playlists</b>
                    <b onClick={this.featuredPlaylists} style={{marginLeft: 50}}>Featured Playlists</b>
                </div>
                <div id='playlists-list'>

                </div>
            </div>
        )
    }
}
export default Playlists;