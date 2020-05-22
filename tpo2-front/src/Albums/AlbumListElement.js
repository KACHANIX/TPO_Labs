import React, {Component} from "react";
import './AlbumListElement.css'
import {addAlbumToSaved, removeAlbumFromSaved,} from "../Utils/AlbumUtils";

class AlbumListElement extends Component {
    constructor(props) {
        super(props);
        this.saveAlbum = this.saveAlbum.bind(this);
        this.removeAlbum = this.removeAlbum.bind(this);
        this.redirectToAlbum = this.redirectToAlbum.bind(this)
    }

    async saveAlbum() {
        alert('Album saved!');
        await addAlbumToSaved(this.props.id);
    }

    async removeAlbum() {
        alert('Album unsaved!');
        await removeAlbumFromSaved([this.props.id]);
    }

    redirectToAlbum() {
        window.location.href = 'http://localhost:3000/albums/album/' + this.props.id;
    }

    render() {
        return (
            <div class='album-list-element'>
                <div class='album-definition' onClick={this.redirectToAlbum}>
                    <div className='album-name'>
                        {this.props.name}
                    </div>
                    <div className='album-author'>
                        {this.props.artist}
                    </div>
                </div>
                <div class='album-list-buttons'>
                    <button onClick={this.saveAlbum}>Save Album</button>
                    <button onClick={this.removeAlbum}>Unsave Album</button>
                </div>
            </div>
        )
    }
}

export default AlbumListElement;