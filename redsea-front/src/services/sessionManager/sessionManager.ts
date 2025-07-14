interface SessionState {
  isRunning: boolean;
  isInFocus: boolean;
  duration: number;
  intervalId?: number;
}

interface SessionManager {
  startSession: () => void;
  pauseSession: () => void;
  resetSession: () => void;
  destroy: () => void;
}

export const sessionManager = (): SessionManager => {
  let state: SessionState = {
    isRunning: false,
    isInFocus: !document.hidden,
    duration: 0,
  };

  const handleVisibilityChange = () => {
    state.isInFocus = !document.hidden;
  };

  const handleWindowFocus = () => {
    state.isInFocus = true;
  };

  const handleWindowBlur = () => {
    state.isInFocus = false;
  };

  const setupEventListeners = () => {
    document.addEventListener('visibilitychange', handleVisibilityChange);
    window.addEventListener('focus', handleWindowFocus);
    window.addEventListener('blur', handleWindowBlur);
  };

  const cleanupEventListeners = () => {
    document.removeEventListener('visibilitychange', handleVisibilityChange);
    window.removeEventListener('focus', handleWindowFocus);
    window.removeEventListener('blur', handleWindowBlur);
  };

  setupEventListeners();

  const startSession = () => {
    if (state.isRunning) return;

    state.isRunning = true;
    state.isInFocus = !document.hidden;
    state.duration = 0;

    state.intervalId = window.setInterval(() => {
      state.duration += 1;
      console.log(`Session duration: ${state.duration} seconds`);
    }, 1000);
  };

  const pauseSession = () => {
    if (!state.isRunning) return;
    if (state.intervalId) {
      clearInterval(state.intervalId);
    }
    state.isRunning = false;
  };

  const resetSession = () => {
    pauseSession();
    state = {
      isRunning: false,
      isInFocus: !document.hidden, // Reset but check current visibility
      duration: 0,
    };
  };

  const destroy = () => {
    resetSession();
    cleanupEventListeners();
  };

  return {
    startSession,
    pauseSession,
    resetSession,
    destroy,
  };
};
