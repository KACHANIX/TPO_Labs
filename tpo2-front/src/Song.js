import React, {Component} from "react";
import api from "./GetToken";
import './Song.css'
class Song extends Component {
    constructor(props) {
        super(props);
        this.saveTrack=this.saveTrack.bind(this);
        this.removeTrack=this.removeTrack.bind(this);
    }

    async saveTrack(event) {
        let Api = api();
        await Api.addToMySavedTracks([this.props.id]);
    }

    async removeTrack(event) {
        let Api = api();
        await Api.removeFromMySavedTracks([this.props.id]);
    }

    render() {
        return (
            <div id='song'>
                <div id='track-def'>
                    {this.props.name} - {this.props.artist} {this.props.duration}
                </div>
                <div id='track-buttons'>
                    <button onClick={this.saveTrack}>Save Track</button>
                    <button onClick={this.removeTrack}>Unsave Track</button>
                </div>
            </div>
        )
    }
}

export default Song;