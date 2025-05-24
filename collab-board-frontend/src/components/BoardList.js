import { useEffect, useState, useCallback } from 'react';
import api from '../api/api';

export default function BoardList() {
  const [boards, setBoards] = useState([]);

  const fetchBoards = useCallback(async () => {
    try {
      const res = await api.get('/boards');
      setBoards(res.data);
    } catch (err) {
      console.error('Failed to fetch boards', err);
    }
  }, []);

  useEffect(() => {
    fetchBoards();
  }, [fetchBoards]);

  return (
    <div>
      <h2>Your Boards</h2>
      <ul>
        {boards.map((b) => (
          <li key={b.id}>{b.name}</li>
        ))}
      </ul>
    </div>
  );
}
