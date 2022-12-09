use crate::solutions::Solution;

pub struct Day01;

impl Solution for Day01 {
    fn name(&self) -> &'static str {
        "Calorie Counting"
    }

    /// Returns total Calories carried by the Elf carrying the most Calories
    fn solve_part_one(&self, input: &str) -> i32 {
        let elves = build_elves(input);

        elves
            .iter()
            .map(|elf| elf.iter().sum::<i32>())
            .max()
            .unwrap()
    }

    /// Returns total Calories carried by top three Elves carrying the most Calories
    fn solve_part_two(&self, input: &str) -> i32 {
        let elves = build_elves(input);

        let mut calorie_counts: Vec<i32> =
            elves.iter().map(|elf| elf.iter().sum::<i32>()).collect();

        calorie_counts.sort();

        calorie_counts.iter().rev().take(3).sum::<i32>()
    }
}

fn build_elves(input: &str) -> Vec<Vec<i32>> {
    let lines: Vec<&str> = input.lines().collect();
    let mut elves: Vec<Vec<i32>> = vec![Vec::new()];

    // POSSIBLE_TODO: reimplementation with functional equivalent?
    for food_item in lines {
        if food_item.is_empty() {
            elves.push(Vec::new());
        } else {
            elves
                .last_mut()
                .unwrap()
                .push(food_item.parse::<i32>().unwrap());
        }
    }

    elves
}

#[cfg(test)]
mod tests_2022_01 {
    use super::*;

    #[test]
    fn elf_vectors() {
        let elves = build_elves(TEST_INPUT);

        assert_eq!(5, elves.len());
        assert_eq!(vec![1000, 2000, 3000], elves[0]);
        assert_eq!(vec![4000], elves[1]);
        assert_eq!(vec![5000, 6000], elves[2]);
        assert_eq!(vec![7000, 8000, 9000], elves[3]);
        assert_eq!(vec![10000], elves[4]);
    }

    #[test]
    fn solve_part_one_max_total_calories() {
        let solution = Day01;
        let result = solution.solve_part_one(TEST_INPUT);

        assert_eq!(24000, result);
    }

    #[test]
    fn solve_part_two_top_three_total_calories() {
        let solution = Day01;
        let result = solution.solve_part_two(TEST_INPUT);

        assert_eq!(45000, result);
    }

    const TEST_INPUT: &'static str = "\
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
}
