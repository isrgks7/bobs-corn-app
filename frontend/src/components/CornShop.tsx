import React, { useState, useEffect } from 'react';
import axios from 'axios';
import {
  Button,
  Typography,
  Box,
  Alert,
  CircularProgress,
  TextField,
} from '@mui/material';

const API_BASE_URL = 'http://localhost:5000/api/corn';

const CornShop = () => {
  const [clientId, setClientId] = useState('');
  const [purchasedCount, setPurchasedCount] = useState(0);
  const [message, setMessage] = useState('');
  const [loading, setLoading] = useState(false);
  const [waitTime, setWaitTime] = useState<number | null>(null);

  const buyCorn = async () => {
    if (!clientId.trim()) {
      setMessage('Please enter a Client ID.');
      return;
    }

    if (waitTime !== null && waitTime > 0) {
      return;
    }

    setLoading(true);
    setMessage('');
    try {
      const response = await axios.post(`${API_BASE_URL}/${clientId}`);
      if (response.status === 200) {
        setPurchasedCount(prev => prev + 1);
        setMessage('🌽 Corn purchased!');
      }
    } catch (error: any) {
      if (error.response?.status === 429) {
        setMessage('🌽 Too many requests - please wait a minute');
        if (waitTime === null) {
          setWaitTime(60);
        }
      } else {
        setMessage('Error buying corn.');
      }
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    if (waitTime === null) return;

    const timer = setInterval(() => {
      setWaitTime(prev => {
        if (prev === null || prev <= 1) {
          clearInterval(timer);
          return null;
        }
        return prev - 1;
      });
    }, 1000);

    return () => clearInterval(timer);
  }, [waitTime]);

  return (
    <Box
      sx={{
        maxWidth: 400,
        mx: 'auto',
        mt: 10,
        p: 3,
        border: '1px solid #ccc',
        borderRadius: 2,
      }}
    >
      <Typography variant="h4" component="h1" gutterBottom>
        Buy Corn 🌽
      </Typography>

      <TextField
        fullWidth
        label="Client ID"
        value={clientId}
        onChange={(e) => setClientId(e.target.value)}
        sx={{ mb: 2 }}
      />

      <Typography variant="subtitle1" gutterBottom>
        Corn purchased: <strong>{purchasedCount}</strong>
      </Typography>

      <Button
        variant="contained"
        color="primary"
        onClick={buyCorn}
        disabled={loading}
        fullWidth
      >
        {loading ? <CircularProgress size={24} /> : 'Buy Corn'}
      </Button>

      {message && (
        <Alert
          severity={
            message.startsWith('🌽 Too many')
              ? 'warning'
              : message.startsWith('Please enter')
              ? 'info'
              : 'success'
          }
          sx={{ mt: 2 }}
        >
          {message}
        </Alert>
      )}

      {waitTime !== null && (
        <Typography sx={{ mt: 1 }} variant="body2" color="text.secondary">
          ⏳ Please wait {waitTime} second{waitTime !== 1 ? 's' : ''} before trying again.
        </Typography>
      )}
    </Box>
  );
};

export default CornShop;
