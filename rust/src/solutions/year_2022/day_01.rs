use crate::solutions::Solution;

pub struct Day01;

impl Solution for Day01 {
    fn name(&self) -> &'static str {
        "Calorie Counting"
    }

    fn solve_part_one(&self, input: &str) -> i32 {
        let elves = build_elves(&input);

        let max = elves
            .iter()
            .map(|elf| elf.food_items.iter().sum::<u32>())
            .max()
            .unwrap_or(0);

        max as i32
    }

    fn solve_part_two(&self, input: &str) -> i32 {
        input.len() as i32 - input.len() as i32
    }
}

// POSSIBLE_TODO: reimplementation with functional equivalent?
fn build_elves(input: &str) -> Vec<Elf> {
    let lines: Vec<&str> = input.lines().collect();
    let mut elves: Vec<Elf> = vec![Elf {
        food_items: Vec::new(),
    }];

    for line in lines {
        if line.is_empty() {
            elves.push(Elf {
                food_items: Vec::new(),
            });
        } else {
            elves
                .last_mut()
                .unwrap()
                .food_items
                .push(line.parse::<u32>().unwrap());
        }
    }

    elves
}

struct Elf {
    food_items: Vec<u32>,
}

#[cfg(test)]
mod tests_2022_01 {
    use super::*;

    #[test]
    fn input_into_elves() {
        let elves = build_elves(TEST_INPUT);

        assert_eq!(5, elves.len());
        assert_eq!(vec![1000, 2000, 3000], elves[0].food_items);
        assert_eq!(vec![4000], elves[1].food_items);
        assert_eq!(vec![5000, 6000], elves[2].food_items);
        assert_eq!(vec![7000, 8000, 9000], elves[3].food_items);
        assert_eq!(vec![10000], elves[4].food_items);
    }

    #[test]
    fn solve_part_one_returns_max_total_calories() {
        let solution = Day01;

        let result = solution.solve_part_one(TEST_INPUT);

        assert_eq!(24000, result);
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
