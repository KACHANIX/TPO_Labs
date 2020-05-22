import React, {Component} from "react";
import {followPlaylist, unfollowPlaylist} from "../Utils/PlaylistUtils";
import './PlaylistListElement.css'

class PlaylistListElement extends Component {
    constructor(props) {
        super(props);
        this.savePlaylist = this.savePlaylist.bind(this);
        this.removePlaylist = this.removePlaylist.bind(this);
        this.redirectToPlaylist = this.redirectToPlaylist.bind(this);
    }

    async savePlaylist() {
        alert('Playlist saved!');
        await followPlaylist(this.props.id);
    }

    async removePlaylist() {
        alert('Playlist unsaved!');
        await unfollowPlaylist(this.props.id);
    }

    redirectToPlaylist() {
        window.location.href = 'http://localhost:3000/playlists/playlist/' + this.props.id;
    }

    render() {
        return (
            <div class='playlist-list-element'>
                <div class='playlist-definition' onClick={this.redirectToPlaylist}>
                    <div className='playlist-name'>
                        {this.props.name}
                    </div>
                    <div className='playlist-author'>
                        {this.props.artist}
                    </div>
                </div>
                <div class='playlist-list-buttons'>
                    <button onClick={this.savePlaylist}>Save Playlist</button>
                    <button onClick={this.removePlaylist}>Unsave Playlist</button>
                </div>
            </div>
        );
    }
}

export default PlaylistListElement;