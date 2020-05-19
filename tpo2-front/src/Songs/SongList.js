import React, {Component} from "react";
import Song from "./Song";

class SongList extends Component {
    constructor(props){
        super(props);
        console.log(props.songs)
    }
    render() {
        return (
            <div >
                {this.props.songs.map((song) => {
                    return <Song name={song.name} artist={song.artists[0].name} duration={song.duration} id={song.id}/>
                })}
            </div>
        )
    }
}

export default SongList;