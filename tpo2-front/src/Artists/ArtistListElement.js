import React, {Component} from "react";
import './ArtistListElement.css'
import {followArtist, unfollowArtist} from "../Utils/ArtistUtils";

class ArtistListElement extends Component {

    constructor(props) {
        super(props);
        this.saveArtist = this.saveArtist.bind(this);
        this.removeArtist = this.removeArtist.bind(this)
        this.redirectToArtist = this.redirectToArtist.bind(this)
    }

    async saveArtist() {
        await followArtist(this.props.id)
    }

    async removeArtist() {
        await unfollowArtist(this.props.id)
    }

    redirectToArtist() {
        window.location.href = 'http://localhost:3000/artists/artist/' + this.props.id;

    }

    render() {
        return (
            <div class='artist-list-element'>
                <div class='album-definition' onClick={this.redirectToArtist}>
                    {this.props.name}
                </div>
                <div class='album-list-buttons'>
                    <button onClick={this.saveArtist}>Save Artist</button>
                    <button onClick={this.removeArtist}>Unsave Artist</button>
                </div>
            </div>
        )
    }
}

export default ArtistListElement;