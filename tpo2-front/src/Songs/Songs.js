import React, {Component} from 'react';
import {getRecentTracks, getSavedTracks, getTopTracks} from "../Utils/SongUtils";
import SongList from "./SongList";
import * as ReactDOM from "react-dom";

class Songs extends Component {
    constructor() {
        super();
        this.savedTracks = this.savedTracks.bind(this);
        this.mostTracks = this.mostTracks.bind(this);
        this.recentTracks = this.recentTracks.bind(this);
    }

    async savedTracks(event) {
        let songs = await getSavedTracks();
        ReactDOM.render(<SongList songs={songs}/>, document.getElementById('songList'));
    }

    async mostTracks(event) {
        // let asd = getTopTracks();
        // console.log(asd)
    }

    async recentTracks(event) {
        let songs = await getRecentTracks();
        ReactDOM.render(<SongList songs={songs}/>, document.getElementById('songList'));

    }

    render() {
        return (
            <div>
                <div>
                    <b onClick={this.savedTracks}>Saved Songs</b>
                    <b style={{marginLeft: 30}} onClick={this.mostTracks}>Most Played Songs</b>
                    <b style={{marginLeft: 30}} onClick={this.recentTracks}>Recently Played Songs</b>
                </div>
                <div id='songList'>
                </div>
            </div>
        )
    }
}

export default Songs;