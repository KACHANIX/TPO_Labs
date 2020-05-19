import React, {Component} from "react";
import {getArtist, getArtistsAlbums, getArtistsAlike, getArtistsTopTracks} from "../Utils/ArtistUtils";
import * as ReactDOM from "react-dom";
import ArtistList from "./ArtistList";
import AlbumList from "../Albums/AlbumList";
import SongList from "../Songs/SongList";

class Artist extends Component {
    constructor() {
        super();
        this.state = {
            artistId: ''
        };
        this.artistsAlike = this.artistsAlike.bind(this);
        this.artistsAlbums = this.artistsAlbums.bind(this);
        this.artistsTopSongs = this.artistsTopSongs.bind(this);
    }

    async componentDidMount() {
        this.state.artistId = this.props.match.params.artistId;
        let artist = await getArtist(this.state.artistId);
        console.log(artist);
        document.getElementById('artist-definition').innerText = artist.name + '\nSubs: ' + artist.followers.total + '\nPopularity: ' + artist.popularity;
    }

    async artistsAlike() {
        let artists = await getArtistsAlike(this.state.artistId);
        console.log(artists);
        ReactDOM.render(<ArtistList artists={artists}/>, document.getElementById('items-list'));

    }

    async artistsAlbums() {
        let albums = await getArtistsAlbums(this.state.artistId);
        console.log(albums);
        ReactDOM.render(<AlbumList albums={albums}/>, document.getElementById('items-list'));

    }

    async artistsTopSongs() {
        let songs = await getArtistsTopTracks(this.state.artistId);
        console.log(songs);
        ReactDOM.render(<SongList songs={songs}/>, document.getElementById('items-list'));

    }

    render() {
        return (
            <div>
                <div id='artist-definition'></div>
                <div>
                    <b onClick={this.artistsAlike}>Artists Like This</b>
                    <b onClick={this.artistsAlbums} style={{marginLeft: 30}}>Albums</b>
                    <b onClick={this.artistsTopSongs} style={{marginLeft: 30}}>Top Songs</b>
                </div>
                <div id='items-list'></div>
            </div>
        );
    }
}

export default Artist;