
export const convertTime = (hour: number): string => {
    const suffix = hour >= 12 ? " PM" : " AM";
    const hours = ((hour + 11) % 12 + 1) + suffix;
    return hours.toString();
};
