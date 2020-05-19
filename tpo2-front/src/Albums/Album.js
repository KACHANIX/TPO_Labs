import React, {Component} from "react";
import api from "../GetToken";
import {getAlbum} from "../Utils/AlbumUtils";
import * as ReactDOM from "react-dom";
import SongList from "../Songs/SongList";

class Album extends Component {
    async componentDidMount() {
        let album = await getAlbum(this.props.match.params.albumId);
        document.getElementById('album-definition').innerText = album.name + '\n by : ' + album.artists[0].name + '\n ' + album.release_date.substring(0, 4);
        ReactDOM.render(<SongList songs={album.tracks.items}/>, document.getElementById('songList'));
    }

    render() {
        return (
            <div>
                <div id='album-definition'></div>
                <div id='songList'></div>
            </div>
        );
    }
}

export default Album;