import React, {Component} from "react";
import {getAlbum} from "../Utils/AlbumUtils";
import * as ReactDOM from "react-dom";
import SongList from "../Songs/SongList";

class Album extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            artist: '',
            date: ''
        }
    }

    async componentDidMount() {
        let album = await getAlbum(this.props.match.params.albumId);
        this.setState({
            name: album.name,
            artist: album.artists[0].name,
            date: album.release_date.substring(0, 4)
        });
        ReactDOM.render(<SongList songs={album.tracks.items}/>, document.getElementById('songList'));
    }

    render() {
        return (
            <div>
                <div id='album-definition'>
                    {this.state.name}<br/>
                    by: {this.state.artist}<br/>
                    {this.state.date}
                </div>
                <div id='songList'></div>
            </div>
        );
    }
}

export default Album;