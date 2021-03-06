import React, {Component} from "react";
import Song from "./Song";

class SongList extends Component {
    render() {
        return (
            <div id="songs">
                {this.props.songs.map((song) => {
                    return <Song name={song.name} artist={song.artists[0].name} duration={song.duration} id={song.id}/>
                })}
            </div>
        )
    }
}

export default SongList;