use crate::Solution;

mod day_01;
mod day_02;
mod day_03;
mod day_04;

pub const ALL_SOLUTIONS: [&dyn Solution; 4] = [
    &day_01::Day01,
    &day_02::Day02,
    &day_03::Day03,
    &day_04::Day04,
];
