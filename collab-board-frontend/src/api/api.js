import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5059/api',
  withCredentials: true
});

api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

api.interceptors.response.use(
  res => res,
  err => {
    return Promise.reject(err);
  }
);

export default api;
