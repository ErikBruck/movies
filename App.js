import React, { useEffect, useRef, useState } from 'react';
import './App.css';

function App() {
  const [movies, setMovies] = useState([]);
  const nameRef = useRef();
  const ratingRef = useRef();
  const yearRef = useRef();
  const posterUrlRef = useRef();

  useEffect(() => {
    fetch("https://localhost:4444/movies")
      .then(res => res.json())
      .then(json => {
        setMovies(json);
        console.log('Fetched movies:', json);  // Debugging log
      })
      .catch(error => console.error('Error fetching data:', error));
  }, []);

  function deleteMovie(index) {
    fetch("https://localhost:4444/movies/delete/" + index, {
      method: "DELETE"
    })
      .then(res => res.json())
      .then(json => {
        setMovies(json);
        console.log('Deleted movie:', json);  // Debugging log
      })
      .catch(error => console.error('Error deleting movie:', error));
  }

  function addMovie() {
    const newMovie = {
      name: nameRef.current.value,
      rating: Number(ratingRef.current.value),
      year: Number(yearRef.current.value),
      posterUrl: posterUrlRef.current.value
    };

    fetch("https://localhost:4444/movies/add", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(newMovie)
    })
      .then(res => res.json())
      .then(json => {
        setMovies(json);
        console.log('Added movie:', json);  // Debugging log
      })
      .catch(error => console.error('Error adding movie:', error));
  }

  return (
    <div className="App">
      <div className="movie-form">
        <label>Name</label> <br />
        <input ref={nameRef} type="text" /> <br />
        <label>Rating</label> <br />
        <input ref={ratingRef} type="number" step="0.1" /> <br />
        <label>Year</label> <br />
        <input ref={yearRef} type="number" /> <br />
        <label>Poster URL</label> <br />
        <input ref={posterUrlRef} type="text" /> <br />
        <button onClick={addMovie}>Add Movie</button>
      </div>
      
      <div className="movie-list">
        {movies.map((movie, index) => (
          <div className="movie-item" key={index}>
            <img 
              src={movie.posterUrl} 
              alt={movie.name} 
            />
            <div className="movie-details">
              <h3>{movie.name}</h3>
              <p>Rating: {movie.rating}</p>
              <p>Year: {movie.year}</p>
            </div>
            <div className="movie-actions">
              <button onClick={() => deleteMovie(index)}>Delete</button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;
