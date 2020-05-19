import React, {Component} from "react";
import api from "../GetToken";
import './AlbumListElement.css'
import {useHistory} from "react-router-dom";
import Redirect from "react-router-dom/es/Redirect";

let Api = api();

class AlbumListElement extends Component {
    constructor(props) {
        super(props);
        this.state = {
            redirect: false
        }
        this.saveAlbum = this.saveAlbum.bind(this);
        this.removeAlbum = this.removeAlbum.bind(this)
        this.redirectToAlbum = this.redirectToAlbum.bind(this)
        // this.setRedirect = this.setRedirect.bind(this)
        // this.renderRedirect = this.renderRedirect.bind(this)
    }

    async saveAlbum() {
        await Api.addToMySavedAlbums([this.props.id])
    }

    async removeAlbum() {
        await Api.removeFromMySavedAlbums([this.props.id])
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