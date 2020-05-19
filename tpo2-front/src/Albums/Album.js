import React, {Component} from "react";
import api from "../GetToken";
import {getAlbum} from "../Utils/AlbumUtils";
import * as ReactDOM from "react-dom";
import SongList from "../Songs/SongList";

let Api = api();

class Album extends Component {
    constructor(props) {
        super(props);
    }

    async componentDidMount() {
        let album = await getAlbum(this.props.match.params.albumId);
        console.log(album);
        document.getElementById('album-definition').innerText = album.name + '\n by : ' + album.artists[0].name + '\n '+ album.release_date.substring(0,4);
        ReactDOM.render(<SongList name='asd' songs={album.tracks.items}/>, document.getElementById('songList'));
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