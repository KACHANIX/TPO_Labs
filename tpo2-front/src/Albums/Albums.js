import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import {getNewAlbums, getSavedAlbums} from "../Utils/AlbumUtils";
import * as ReactDOM from "react-dom";
import AlbumList from "./AlbumList";

class Albums extends Component {
    constructor(){
        super();
        this.savedAlbums = this.savedAlbums.bind(this);
        this.releasedAlbums = this.releasedAlbums.bind(this);
    }

    async savedAlbums(event){
        let a = await getSavedAlbums();
        ReactDOM.render(<AlbumList name='asd' albums={a}/>, document.getElementById('albums-list'));
        console.log(a);

    }
    async releasedAlbums(event){
        let a = await getNewAlbums();
        ReactDOM.render(<AlbumList name='asd' albums={a}/>, document.getElementById('albums-list'));
        console.log(a);
    }
    render() {
        return (
        <div>
            <div>
                <b onClick={this.savedAlbums}>Saved Albums</b>
                <b onClick={this.releasedAlbums} style={{marginLeft:50}}>New Album Releases</b>
            </div>
            <div id='albums-list'>

            </div>
        </div>

            )
    }
}

export default Albums;