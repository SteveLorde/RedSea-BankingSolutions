import { useState } from 'react';
import Calendar from 'react-calendar';
import { Value } from 'react-calendar/src/shared/types.js';

export default function CalendarComponent() {
  const [toggleHijri, setToggleHijri] = useState<boolean>(false);
  const [value, onChange] = useState<Value>(new Date());

  return (
    <div>
      {toggleHijri ? (
        <Calendar onChange={onChange} value={value} />
      ) : (
        <Calendar onChange={onChange} value={value} />
      )}
    </div>
  );
}
