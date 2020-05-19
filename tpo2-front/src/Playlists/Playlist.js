import React, {Component} from "react";
import {getPlaylist} from "../Utils/PlaylistUtils";
import * as ReactDOM from "react-dom";
import SongList from "../Songs/SongList";

class Playlist extends Component{
    async componentDidMount() {
        let  playlist = await getPlaylist(this.props.match.params.playlistId);
        console.log(playlist);
        document.getElementById('playlist-definition').innerText = playlist.name + '\n by : ' + playlist.owner.display_name;
        ReactDOM.render(<SongList name='asd' songs={playlist.trackList}/>, document.getElementById('playlist-list'));

    }


    render() {
        return (
            <div>
                <div id='playlist-definition'></div>
                <div id='playlist-list'></div>
            </div>
        );
    }
}
export default Playlist;