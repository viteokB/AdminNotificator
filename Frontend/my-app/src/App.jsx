import { useState } from 'react';

function App() {
  const [response, setResponse] = useState('');
  const [loading, setLoading] = useState(false);

  const sendRequest = async () => {
    setLoading(true);
    try {
      const res = await fetch('https://localhost:7270/api/emailTypes');
      const data = await res.text();
      setResponse(data);
    } catch (error) {
      setResponse('Ошибка: ' + error.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ padding: '2rem', fontFamily: 'Arial' }}>
      <h1>Запрос к серверу</h1>
      <button onClick={sendRequest} disabled={loading}>
        {loading ? 'Загрузка...' : 'Отправить запрос'}
      </button>
      <pre style={{ marginTop: '1rem', whiteSpace: 'pre-wrap' }}>
        {response}
      </pre>
    </div>
  );
}

export default App;


