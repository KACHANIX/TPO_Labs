import React, {Component} from 'react';
import * as ReactDOM from "react-dom";
import {getCreatedPlaylists, getFeaturedPlaylists, getSavedPlaylists} from "../Utils/PlaylistUtils";
import PlaylistList from "./PlaylistList";


class Playlists extends Component {

    constructor() {
        super();
        this.savedPlaylists = this.savedPlaylists.bind(this);
        this.createdPlaylists = this.createdPlaylists.bind(this);
        this.featuredPlaylists = this.featuredPlaylists.bind(this);
    }

    async savedPlaylists() {
        let playlists = await getSavedPlaylists();
        ReactDOM.render(<PlaylistList playlists={playlists}/>, document.getElementById('playlists-list'));
    }

    async createdPlaylists() {
        let playlists = await getCreatedPlaylists();
        ReactDOM.render(<PlaylistList playlists={playlists}/>, document.getElementById('playlists-list'));
    }

    async featuredPlaylists() {
        let playlists = await getFeaturedPlaylists();
        ReactDOM.render(<PlaylistList playlists={playlists}/>, document.getElementById('playlists-list'));
    }

    render() {
        return (
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