import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import api from "./GetToken"
import {getRecentTracks, getSavedTracks, getTopTracks} from "./Utils/SongUtils";
import SongList from "./SongList";
import * as ReactDOM from "react-dom";

let Api = api();
class Songs extends Component {
    constructor() {
        super();
        Api.getMe().then(function (data) {
            console.log(data);
        });
        this.savedTracks = this.savedTracks.bind(this);
        this.mostTracks = this.mostTracks.bind(this);
        this.recentTracks = this.recentTracks.bind(this);
    }

    async savedTracks(event) {
        let asd = await getSavedTracks();
        console.log(asd);

        ReactDOM.render(<SongList name='asd' songs={asd}/>, document.getElementById('songList'));
    }

    mostTracks(event) {
        // let asd = getTopTracks();
        // console.log(asd)
    }

    async recentTracks(event) {
        let asd = await getRecentTracks();
        ReactDOM.render(<SongList name='dsa' songs={asd}/>, document.getElementById('songList'));

    }

    render() {
        return (
            <div>
                <div>
                    <b onClick={this.savedTracks}>Saved Tracks</b>
                    <b style={{marginLeft:30}} onClick={this.mostTracks}>Most Played Songs</b>
                    <b style={{marginLeft:30}} onClick={this.recentTracks}>Recently Played Songs</b>
                </div>
                <div id='songList'>

                </div>
            </div>
        )
    }
}

export default Songs;