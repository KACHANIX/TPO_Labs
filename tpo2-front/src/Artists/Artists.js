import React, {Component} from 'react';
import {getMostArtists, getSavedArtists} from "../Utils/ArtistUtils";
import * as ReactDOM from "react-dom";
import ArtistList from "./ArtistList";

class Artists extends Component {
    constructor() {
        super();
        this.savedArtists = this.savedArtists.bind(this);
        this.mostArtists = this.mostArtists.bind(this);
    }

    async savedArtists() {
        let artists = await getSavedArtists();
        ReactDOM.render(<ArtistList artists={artists}/>, document.getElementById('artists-list'));
    }

    async mostArtists() {
        let artists = await getMostArtists();
        ReactDOM.render(<ArtistList artists={artists}/>, document.getElementById('artists-list'));
    }

    render() {
        return (
            <div>
                <div>
                    <b onClick={this.savedArtists}>Saved Artists</b>
                    <b onClick={this.mostArtists} style={{marginLeft: 50}}>Most Listened Artists</b>
                </div>
                <div id='artists-list'>
                </div>
            </div>

        );
    }
}

export default Artists;