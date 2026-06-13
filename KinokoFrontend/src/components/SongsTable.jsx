import { useEffect, useState } from "react";
import axios from "axios";

export default function SongsTable() {
  const baseUrl = "http://localhost:5277/api/songs";

  const [songs, setSongs] = useState([]);

  const [title, setTitle] = useState("");
  const [fileName, setFileName] = useState("");
  const [duration, setDuration] = useState(""); // "00:03:45"

  // GET ALL
  const loadSongs = async () => {
    const res = await axios.get(baseUrl);
    setSongs(res.data);
  };

  useEffect(() => {
    loadSongs();
  }, []);

  // CREATE
  const addSong = async () => {
    if (!title || !fileName || !duration) return;

    await axios.post(baseUrl, {
      title,
      fileName,
      duration // string "HH:mm:ss"
    });

    setTitle("");
    setFileName("");
    setDuration("");
    loadSongs();
  };

  // DELETE
  const deleteSong = async (id) => {
    await axios.delete(`${baseUrl}/${id}`);
    loadSongs();
  };

  return (
    <div style={{ padding: 20 }}>
      <h2>🎵 Songs</h2>

      {/* FORM */}
      <div style={{ marginBottom: 20 }}>
        <input
          placeholder="Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
        />

        <input
          placeholder="File name"
          value={fileName}
          onChange={(e) => setFileName(e.target.value)}
        />

        <input
          placeholder="Duration (00:03:45)"
          value={duration}
          onChange={(e) => setDuration(e.target.value)}
        />

        <button onClick={addSong}>Add</button>
      </div>

      {/* TABLE */}
      <table border="1" cellPadding="10">
        <thead>
          <tr>
            <th>ID</th>
            <th>Title</th>
            <th>File</th>
            <th>Duration</th>
            <th>Date</th>
            <th>Actions</th>
          </tr>
        </thead>

        <tbody>
          {songs.map((s) => (
            <tr key={s.id}>
              <td>{s.id}</td>
              <td>{s.title}</td>
              <td>{s.fileName}</td>
              <td>{s.duration}</td>
              <td>{new Date(s.date).toLocaleString()}</td>
              <td>
                <button onClick={() => deleteSong(s.id)}>
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}