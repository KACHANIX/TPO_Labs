import React, {Component} from "react";
import {getPlaylist} from "../Utils/PlaylistUtils";
import * as ReactDOM from "react-dom";
import SongList from "../Songs/SongList";

class Playlist extends Component {
    constructor(props){
        super(props);
        this.state={
            name: '',
            owner:  ''
        }
    }
    async componentDidMount() {
        let playlist = await getPlaylist(this.props.match.params.playlistId);
        this.setState({name:playlist.name,owner:playlist.owner.display_name});
        ReactDOM.render(<SongList songs={playlist.trackList}/>, document.getElementById('songs-list'));
    }

    render() {
        return (
            <div>
                <div id='playlist-definition'>
                    {this.state.name}<br/>
                    by: {this.state.owner}
                </div>
                <div id='songs-list'></div>
            </div>
        );
    }
}

export default Playlist;