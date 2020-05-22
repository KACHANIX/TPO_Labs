import React, {Component} from "react";
import AlbumListElement from "./AlbumListElement";

class AlbumList extends Component {
    render() {
        return (
            <div id="albums">
                {this.props.albums.map((album) => {
                    return <AlbumListElement name={album.name} artist={album.artists[0].name} id={album.id}/>
                })}
            </div>
        )
    }
}

export default AlbumList;