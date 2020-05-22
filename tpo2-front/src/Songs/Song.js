import React, {Component} from "react";
import './Song.css';
import {addSongToSaved, removeSongFromSaved} from "../Utils/SongUtils";

class Song extends Component {
    constructor(props) {
        super(props);
        this.saveTrack = this.saveTrack.bind(this);
        this.removeTrack = this.removeTrack.bind(this);
    }

    async saveTrack( ) {
        alert('Song saved!');
        await addSongToSaved(this.props.id);
    }

    async removeTrack( ) {
        alert('Song unsaved!');
        await removeSongFromSaved(this.props.id);
    }

    render() {
        return (
            <div class='song'>
                <div class='track-def'>
                    {this.props.name} - {this.props.artist} {this.props.duration}
                </div>
                <div class='track-buttons'>
                    <button onClick={this.saveTrack}>Save Song</button>
                    <button onClick={this.removeTrack}>Unsave Song</button>
                </div>
            </div>
        )
    }
}

export default Song;