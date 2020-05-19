import React, {Component} from "react";
import api from "../GetToken";
import './Song.css';
import {addSongToSaved, removeSongFromSaved} from "../Utils/SongUtils";

class Song extends Component {
    constructor(props) {
        super(props);
        this.saveTrack = this.saveTrack.bind(this);
        this.removeTrack = this.removeTrack.bind(this);
    }

    async saveTrack(event) {
        await addSongToSaved(this.props.id);
    }

    async removeTrack(event) {
        await removeSongFromSaved(this.props.id);
    }

    render() {
        return (
            <div class='song'>
                <div class='track-def'>
                    {this.props.name} - {this.props.artist} {this.props.duration}
                </div>
                <div class='track-buttons'>
                    <button onClick={this.saveTrack}>Save Track</button>
                    <button onClick={this.removeTrack}>Unsave Track</button>
                </div>
            </div>
        )
    }
}

export default Song;