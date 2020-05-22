import React, {Component} from "react";
import ArtistListElement from "./ArtistListElement";

class ArtistList extends Component {
    render() {
        return (
            <div id="artists">
                {this.props.artists.map((artist) => {
                    return <ArtistListElement name={artist.name} id={artist.id}/>
                })}
            </div>
        )
    }
}

export default ArtistList;