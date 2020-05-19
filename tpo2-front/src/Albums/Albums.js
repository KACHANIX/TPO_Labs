import React, {Component} from 'react';
import {getNewAlbums, getSavedAlbums} from "../Utils/AlbumUtils";
import * as ReactDOM from "react-dom";
import AlbumList from "./AlbumList";

class Albums extends Component {
    constructor() {
        super();
        this.savedAlbums = this.savedAlbums.bind(this);
        this.releasedAlbums = this.releasedAlbums.bind(this);
    }

    async savedAlbums() {
        let albums = await getSavedAlbums();
        ReactDOM.render(<AlbumList albums={albums}/>, document.getElementById('albums-list'));
    }

    async releasedAlbums() {
        let albums = await getNewAlbums();
        ReactDOM.render(<AlbumList albums={albums}/>, document.getElementById('albums-list'));
    }

    render() {
        return (
            <div>
                <div>
                    <b onClick={this.savedAlbums}>Saved Albums</b>
                    <b onClick={this.releasedAlbums} style={{marginLeft: 50}}>New Album Releases</b>
                </div>
                <div id='albums-list'>
                </div>
            </div>

        )
    }
}

export default Albums;