import React, {Component} from "react";
import PlaylistListElement from "./PlaylistListElement";

class PlaylistList extends Component {
    render() {
        return(
            <div>
                {this.props.playlists.map((playlist)=>{
                    return <PlaylistListElement name={playlist.name} artist={playlist.owner.display_name} id={playlist.id}/>
                })}
            </div>
        );
    }
}
export default PlaylistList;