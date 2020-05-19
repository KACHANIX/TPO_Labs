import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import {getMostArtists, getSavedArtists} from "../Utils/ArtistUtils";
import * as ReactDOM from "react-dom";
import ArtistList from "./ArtistList";

class Artists extends Component {
    constructor() {
        super();
        this.savedArtists = this.savedArtists.bind(this);
        this.mostArtists = this.mostArtists.bind(this);
    }

    async savedArtists(){
        let artists = await getSavedArtists();
        ReactDOM.render(<ArtistList name='asd' artists={artists}/>, document.getElementById('artists-list'));

        console.log(artists);
    }
    async mostArtists(){
        let artists = await getMostArtists();
        ReactDOM.render(<ArtistList name='asd' artists={artists}/>, document.getElementById('artists-list'));

        console.log(artists);
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